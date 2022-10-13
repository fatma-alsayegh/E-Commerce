import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { DomSanitizer } from '@angular/platform-browser';
import { CategoryService } from '../Category/service/category.service';
import { Product } from '../models/product';
import { ProductService } from './service/product.service';

@Component({
    selector: 'app-product',
    templateUrl: './product.component.html',
    styleUrls: ['./product.component.css']
})

export class ProductComponent implements OnInit {
    formData = new FormData();
    categoryList: any = [];
    categoryMap: Map<number, string> = new Map();
    filteredCategoryData: any = [];
    tempFilteredData: any = []
    isFormValid = false;
    areCredentialsInvalid = false;
    products: Product[] = [];
    _baseUrl = '';
    _product = {
        id: 0,
        name: "",
        description: "",
        icon: "",
        price: "",
        categoryId: 0,
        quantity: 0
    }
    productsEmpty = false;
    @ViewChild('CloseButtonEdit') CloseButtonEdit;
    @ViewChild('CloseButtonAdd') CloseButtonAdd;
    @ViewChild('productForm') productForm;

    constructor(@Inject('BASE_URL') baseUrl: string, public productService: ProductService, public categoryService: CategoryService, private domSanitizer: DomSanitizer
    ) {
        this._baseUrl = baseUrl;
    }

    ngOnInit() {
        this.fetchData();
        this.categoryTypesMap();
    }

    fetchData() {
        this.productService.getAllProducts().subscribe(
            result => {
                this.products = result;
                this.tempFilteredData = this.products;
            }
        )
    }

    edit(product: any) {
        this._product = new Product();
        this._product.id = product.id;
        this._product.name = product.name;
        this._product.description = product.description;
        this._product.price = product.price;
        this._product.categoryId = product.categoryId;
        this._product.icon = product.icon;
        this.url = product.icon;
    }

    updateProduct(ngForm: NgForm) {
        this.isFormValid = false;
        this._product.name = ngForm.value.name;
        this._product.description = ngForm.value.description;
        this._product.price = ngForm.value.price;
        this._product.categoryId = Number(ngForm.value.categoryId);

        if (this._product.name == "" || this._product.description == "" || this._product.price == "") {
            this.isFormValid = true;
            return;
        }
        this.formData.set('id', this._product.id.toString());
        this.formData.set('name', this._product.name);
        this.formData.set('description', this._product.description);
        this.formData.set('price', this._product.price);
        this.formData.set('categoryId', this._product.categoryId.toString());
        this.formData.set('icon', this.url);

        this.productService.editProduct(this.formData).subscribe(
            result => {
                this.CloseButtonEdit.nativeElement.click();
                this.fetchData();
                this.isFormValid = false;
                this.areCredentialsInvalid = false;
            },
            (err) => {
                this.isFormValid = false;
                console.log(err);
            }
        );
    }

    deleteProduct(product) {
        this.productService.deleteProduct(product.id).subscribe(() => {
            this.products = this.products.filter(
                (u: Product) => u.id !== product.id
            );
            this.fetchData();
        });
        if (this.products.length < 0) {
            this.productsEmpty = true;
        }
    }

    categoryTypesMap() {
        this.categoryService.getAllCategories().subscribe(
            result => {
                this.categoryList = result;
                for (let i = 0; i < result.length; i++) {
                    this.categoryMap.set(this.categoryList[i].id, this.categoryList[i].name)
                }
            }
        )
    }

    filterCategory(event: any) {
        let value = Number(event.target.value);
        if (this.tempFilteredData.length < this.products.length) {
            this.tempFilteredData = this.products;
        }
        var list = this.tempFilteredData;
        this.filteredCategoryData.length = 0;
        if (isNaN(value)) {
            return this.fetchData();
        }
        for (let i = 0; i < list.length; i++) {
            if (value == list[i].categoryId) {

                this.filteredCategoryData.push(this.products[i]);
            }
        }
        this.tempFilteredData = this.filteredCategoryData;
    }

    addProduct(ngForm: NgForm) {
        this._product.name = ngForm.value.name;
        this._product.description = ngForm.value.description;
        this._product.price = ngForm.value.price;
        this._product.categoryId = Number(ngForm.value.categoryId);

        if (!ngForm.valid) {
            this.isFormValid = true;
            return;
        }

        this.formData.set('name', this._product.name);
        this.formData.set('description', this._product.description);
        this.formData.set('price', this._product.price);
        this.formData.set('categoryId', this._product.categoryId.toString());
        this.formData.set('icon', this.url);

        this.productService.addProduct(this.formData).subscribe(
            result => {
                this.CloseButtonAdd.nativeElement.click();
                this.fetchData();
                this.url = "";
                this.isFormValid = false;
                this.productForm.reset();
            }, error => {
                this.isFormValid = false;
                console.log(error);
            }
        );
    }

    url: any;
    msg = "";
    imgReader = new FileReader();
    fileToUpload: File = null;

    selectFile(event: any) {

        if (!event.target.files[0] || event.target.files[0].length == 0) {
            this.msg = 'You must select an image';
            return;
        }

        var mimeType = event.target.files[0].type;

        if (mimeType.match(/image\/*/) == null) {
            this.msg = "Only images are supported";
            return;
        }

        this.formData.append(this._product.id.toString(), event.target.files[0]);
        this.imgReader.readAsDataURL(event.target.files[0]);

        this.imgReader.onload = (_event) => {
            this.msg = "";
            this.url = this.imgReader.result;
        }
    }
}
