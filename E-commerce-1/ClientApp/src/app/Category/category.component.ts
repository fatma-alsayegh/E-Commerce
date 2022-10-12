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
    editCategory = {
        id: null,
        name: "",
        description: "",
        icon: ""
    }
    isFormValid = false;
    areCredentialsInvalid = false;
    constructor( @Inject('BASE_URL') baseUrl: string,
        public service: CategoryService) {
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
        //this.editCategory = category;
        this.editCategory = new Category();
        this.editCategory.id = category.id;
        this.editCategory.name = category.name;
        this.editCategory.description = category.description;
        
    }
    @ViewChild('CloseButtonEdit') CloseButtonEdit;

    updateCategory(ngForm: NgForm) {
        //debugger
        this.editCategory.name = ngForm.value.name;
        this.editCategory.description = ngForm.value.description;
        if (this.editCategory.name == "" || this.editCategory.description=="") {
            this.isFormValid = true;
            this.areCredentialsInvalid = false;
            return;
        }

        this.service.editCategory(this.editCategory).subscribe(
            result => {
                this.CloseButtonEdit.nativeElement.click();
                this.fetchData();
                this.isFormValid = false;
                this.areCredentialsInvalid = false;
            },
            (err) => {
                this.isFormValid = false;
                this.areCredentialsInvalid = true;
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

    addcategory: Category = {
        id: 0,
        icon: '',
        name: '',
        description: ''
    };

    @ViewChild('CloseButtonAdd') CloseButtonAdd;
    @ViewChild('my_form') my_form;

    onProductCreate(ngForm: NgForm) {
        this.addcategory.name = ngForm.value.name;
        this.addcategory.description = ngForm.value.description;
        if (!ngForm.valid) {
            this.isFormValid = true;
            this.areCredentialsInvalid = false;
            return;
        }

        this.formData.set('name', this.addcategory.name);
        this.formData.set('description', this.addcategory.description);
        this.service.addCategory(this.formData).subscribe(
            result => {
                if (result == null) {
                    console.log('duplicate product');
                } else {
                    this.CloseButtonAdd.nativeElement.click();
                    this.fetchData();
                    this.my_form.reset();
                    this.isFormValid = false;
                    this.areCredentialsInvalid = false;
                }
                //this.closebutton.nativeElement.click();
                //this.fetchData();


            }, error => {
                this.isFormValid = false;
                this.areCredentialsInvalid = true;
                console.log(error);
            }
        );

    }
}
