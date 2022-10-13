import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Category } from '../../models/category';

@Injectable({
    providedIn: 'root'
})
export class CategoryService {
    _baseUrl = '';

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this._baseUrl = baseUrl;
    }
    getAllCategories() {
        return this.http.get<Category[]>(this._baseUrl + 'category');
    }

    addCategory(formData: FormData) {
        return this.http.post<Category>(this._baseUrl + 'category', formData);
    }

    editCategory(formData: FormData) {
        return this.http.put<Category>(this._baseUrl + 'category', formData);
    }

    deleteCategory(id) {
        return this.http.delete<Category>(this._baseUrl + 'category?id=' + id);
    }
}
