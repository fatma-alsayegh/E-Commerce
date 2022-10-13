import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../authentication/authentication.service';
import { Order } from '../models/order';
import { Product } from '../models/product';
import { User } from '../models/user';
import { ShoppingCartService } from './service/shopping-cart.service';

@Component({
    selector: 'app-shopping-cart',
    templateUrl: './shopping-cart.component.html',
    styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {
    items: any;
    displayList: any = false;
    displayEmptyList: any = false;
    orders: Order[] = [];;
    totalPriceOfAllProducts: number;
    productCount: number;
    orderNum: number
    user: User[];
    _order = {
        id: 0,
        name: "",
        orderNumber: "",
        productCount: 0,
        totalCost: "",
        status: "",
        userId: 0
    }
    orderDetailsFromDb: Order;

    constructor(public shoopingCartService: ShoppingCartService, private authenticationService: AuthenticationService, private router: Router) { }

    ngOnInit(): void {
        this.getAllItems();
        this.user = this.authenticationService.currentUser;
        this.orderNum = 1;
    }

    getAllItems() {
        this.items = this.shoopingCartService.getItems();
        this.productCount = this.shoopingCartService.productCount;
        this.totalPriceOfAllProducts = Number(this.shoopingCartService.totalPriceOfAllProducts);
        if (this.items.length > 0) {
            this.displayList = true;
        }
        else {
            this.displayEmptyList = true;
        }
    }

    removeItem(product) {
        this.shoopingCartService.clearitem(product);
        this.getAllItems();
    }

    plus(product: Product) {
        this.shoopingCartService.totalPriceOfAllProducts -= (Number(product.price) * product.quantity);
        product.quantity += 1;
        this.shoopingCartService.priceIncrease(product);
        this.shoopingCartService.productCount += 1;
        this.productCount = this.shoopingCartService.productCount;
    }

    minus(product: Product) {
        if (product.quantity < 1) {
            product.quantity = 1;
        }
        if (product.quantity != 1) {
            product.quantity = product.quantity - 1;
        }
        this.shoopingCartService.priceDecrease(product);
        this.shoopingCartService.productCount -= 1;
        this.productCount = this.shoopingCartService.productCount;
    }

    removeAll() {
        this.shoopingCartService.clearCart();
        this.getAllItems();
        this.displayEmptyList = true;
    }

    checkout() {
        this._order.productCount = this.shoopingCartService.productCount;
        this._order.status = 'Processing Order';
        this._order.totalCost = this.totalPriceOfAllProducts.toString();
        this._order.userId = this.user[0].id;
        this.orderNum++;
        this.shoopingCartService.addOrder(this._order).subscribe(
            result => {
                this.orderDetailsFromDb = result;
                this.shoopingCartService.addProductsToOrder(this.orderDetailsFromDb);
            }
        );
        alert('Order is complete. Check the receipt in the profile')
        this.router.navigate(['']);
        this.shoopingCartService.clearCart();
    }
}
