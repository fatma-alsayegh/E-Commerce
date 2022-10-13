import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Product } from '../../models/product';

@Injectable({
    providedIn: 'root'
})
export class ProductService {
    _baseUrl = '';

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this._baseUrl = baseUrl;
    }
    getAllProducts() {
        return this.http.get<Product[]>(this._baseUrl + 'product');
    }

    addProduct(formData: FormData) {
        return this.http.post<Product>(this._baseUrl + 'product', formData);
    }

    editProduct(formData: FormData) {
        return this.http.put<Product>(this._baseUrl + 'product', formData);
    }

    deleteProduct(id) {
        return this.http.delete<Product>(this._baseUrl + 'product?id=' + id);
    }
}
