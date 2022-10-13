import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Category } from '../models/category';
import { CategoryService } from './service/category.service';

@Component({
    selector: 'app-category',
    templateUrl: './category.component.html',
    styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
    categories: Category[] = [];
    _baseUrl = '';
    formData = new FormData();
    _category = {
        id: 0,
        name: '',
        description: '',
        icon: '',
    }
    isFormValid = false;
    //areCredentialsInvalid = false;
    @ViewChild('CloseButtonEditCategory') CloseButtonEditCategory;
    @ViewChild('CloseButtonAddCategory') CloseButtonAddCategory;
    @ViewChild('categoryForm') categoryForm;

    constructor(@Inject('BASE_URL') baseUrl: string, public service: CategoryService) {
        this._baseUrl = baseUrl;
    }

    ngOnInit() {
        this.fetchData();
    }

    fetchData() {
        this.service.getAllCategories().subscribe(
            result => {
                this.categories = result;
            }
        )
    }

    edit(category: any) {
        this._category = new Category();
        this._category.id = category.id;
        this._category.name = category.name;
        this._category.description = category.description;
        this._category.icon = category.icon;
        this.url = category.icon;
    }

    async updateCategory(ngForm: NgForm) {
        this.isFormValid = false;
        this._category.name = ngForm.value.name;
        this._category.description = ngForm.value.description;

        if (this._category.name == "" || this._category.description == "") {
            this.isFormValid = true;
            return;
        }

        this.formData.set('id', this._category.id.toString());
        this.formData.set('name', this._category.name);
        this.formData.set('description', this._category.description);
        this.formData.set('icon', this.url);

        await this.service.editCategory(this.formData).subscribe(
            result => {
                this.CloseButtonEditCategory.nativeElement.click();
                this.fetchData();
                this.isFormValid = false;
            },
            (err) => {
                this.isFormValid = false;
                console.log(err);
            }
        );
    }

    deleteCategory(category) {
        this.service.deleteCategory(category.id).subscribe(() => {
            this.categories = this.categories.filter(
                (u: Category) => u.id !== category.id
            );
            this.fetchData();
        });
    }

    async onProductCreate(ngForm: NgForm) {
        this._category.name = ngForm.value.name;
        this._category.description = ngForm.value.description;

        if (!ngForm.valid) {
            this.isFormValid = true;
            return;
        }

        this.formData.set('name', this._category.name);
        this.formData.set('description', this._category.description);
        this.formData.set('icon', this.url);

        await this.service.addCategory(this.formData).subscribe(
            result => {
                this.CloseButtonAddCategory.nativeElement.click();
                this.fetchData();
                this.url = "";
                this.isFormValid = false;
                this.categoryForm.reset();
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

        this.formData.append(this._category.id.toString(), event.target.files[0]);
        this.imgReader.readAsDataURL(event.target.files[0]);
        this.imgReader.onload = (_event) => {
            this.msg = "";
            this.url = this.imgReader.result;
        }
    }
}
