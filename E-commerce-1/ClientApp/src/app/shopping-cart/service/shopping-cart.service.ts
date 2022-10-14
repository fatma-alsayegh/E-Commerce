import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Order } from '../../models/order';
import { Product } from '../../models/product';
import { Product_Order } from '../../models/product_order';

@Injectable({
    providedIn: 'root'
})

export class ShoppingCartService {
    _baseUrl = '';
    products: Product[] = [];
    totalPriceOfAllProducts: number = 0;
    id: any;
    length: number = 0;
    productCount: number = 0;
    i: any = 0;
    j: any = 0;
    orderNum = 1;
    checkQuantity = 0;
    productsComplete = 0;
    currentProductOrder: Product_Order = {
        orderId: 0,
        productId: 0,
        quantity: 0
    };

    tempProducts: any;
    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this._baseUrl = baseUrl;
    }

    addToCart(product: Product) {
        var p = new Product();
        p.id = product.id;
        p.name = product.name;
        p.description = product.description;
        p.categoryId = product.categoryId;
        p.icon = product.icon;
        p.price = product.price;
        p.quantity = product.quantity;

        if (this.products.findIndex(x => p.id == x.id) == -1) {
            this.products.push(p);
            this.tempProducts = this.products;
        }
        else {
            var existingItem = this.products.filter(x => x.id == p.id)[0];
            existingItem.quantity += p.quantity;
        }
        this.productCount += p.quantity;
        this.priceIncrease(p);
    }

    priceIncrease(product: Product) {
        this.totalPriceOfAllProducts += (Number(product.price) * product.quantity);
    }

    priceDecrease(product: Product) {
        this.totalPriceOfAllProducts -= (Number(product.price) * product.quantity);
    }

    getItems() {
        return this.products;
    }

    clearCart() {
        this.totalPriceOfAllProducts = 0;
        this.productCount = 0;
        return this.products = [];
    }

    clearitem(product: Product) {
        this.id = product.id;
        this.products.splice(this.products.indexOf(this.id), 1);
        this.totalPriceOfAllProducts -= (Number(product.price) * Number(product.quantity));
        return this.products;
    }

    addOrder(order: Order) {
        order.orderNumber = this.orderNum.toString();
        order.name = 'Order Number #' + order.orderNumber;
        ++this.orderNum;
        return this.http.post<Order>(this._baseUrl + 'order', order);
    }


    async addProductsToOrder(order: Order) {
        for (this.i = 0; this.i < order.productCount; this.i++) {
            this.productsComplete += this.tempProducts[this.i].quantity;
            this.currentProductOrder.orderId = order.id;
            this.currentProductOrder.productId = this.tempProducts[this.i].id;
            this.currentProductOrder.quantity = this.tempProducts[this.i].quantity;
            await this.http.post<Product_Order>(this._baseUrl + 'productorder', this.currentProductOrder).subscribe(
                result => {
                }, error => {
                    console.log(error);
                }
            );
            if (this.productsComplete == order.productCount) {
                break;
            }
        }
    }
}