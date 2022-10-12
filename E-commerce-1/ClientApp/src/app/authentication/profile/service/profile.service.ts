import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Order } from '../../../models/order';
import { Product } from '../../../models/product';
import { Product_Order } from '../../../models/product_order';
import { User } from '../../../models/user';
import { AuthenticationService } from '../../authentication.service';


@Injectable({
    providedIn: 'root'
})
export class ProfileService {
    _baseUrl = '';
    profile: User;
    orders: Order[] = [];
    i = 0;
    product_orders: Product_Order[] = [];
    products: Product;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private authService: AuthenticationService,) {
        this._baseUrl = baseUrl;
    }

    async getAllOrders() {
        this.profile = this.authService.currentUser[0];
        var response = await await this.http.get<Order[]>(this._baseUrl + 'order').toPromise();
        if (response) {
            this.orders = response;
            for (this.i; this.i < this.orders.length; this.i++) {
                if (this.profile.id == this.orders[this.i].userId) {
                    var response2 = await this.http.get<Product_Order[]>(this._baseUrl + 'productorder').toPromise();
                    if (response2) {
                        this.product_orders = response2;
                    }
                }
            }
        }
    }

    async getProduct(productId) {
        var response = await await this.http.get<Product>(this._baseUrl + 'product?id=' + productId).toPromise();
        if (response) {
            this.products = response;
        }
    }
}


