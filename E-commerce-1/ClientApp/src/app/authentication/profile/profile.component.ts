import { Component, Inject, OnInit } from '@angular/core';
import { Location } from '../../models/location';
import { Order } from '../../models/order';
import { Product } from '../../models/product';
import { Product_Order } from '../../models/product_order';
import { Role } from '../../models/role';
import { User } from '../../models/user';
import { ProductService } from '../../Product/service/product.service';
import { ShoppingCartService } from '../../shopping-cart/service/shopping-cart.service';
import { AuthenticationService } from '../authentication.service';
import { LoginService } from '../login/service/login.service';
import { ProfileService } from './service/profile.service';


@Component({
    selector: 'app-profile',
    templateUrl: './profile.component.html',
    styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
    profile: User;
    location: Location;
    _baseUrl = '';
    orders: Order[] = [];
    product_orders: Product_Order[] = [];
    products: Product[] = [];
    items: any;
    displayList = false;
    productCount: number;
    role: Role;
    displayCustomerComponents = false;
    i: any;
    tempOrders: Order[] = [];


    constructor(private authService: AuthenticationService,
        @Inject('BASE_URL') baseUrl: string, public productService: ProductService, private profileService: ProfileService, public shoopingCartService: ShoppingCartService,
        private loginService: LoginService) {
        this._baseUrl = baseUrl;
        this.profile = new User();

    }

    async ngOnInit(): Promise<void> {
        await this.fetchDetails();
        await this.fetchAllOrders();
        await this.fetchRole();
    }

    async fetchDetails() {
        this.profile = this.authService.currentUser[0];
        this.location = this.authService.location[0];
    }

    async fetchRole() {
        this.role = this.loginService.role;
        if (this.role.id == 2) {
            this.displayCustomerComponents = true;
        }
    }

    async fetchAllOrders() {
        await this.profileService.getAllOrders();
        this.orders = this.profileService.orders;
        for (this.i = 0; this.i < this.orders.length; this.i++) {
            if (this.orders[this.i].userId == this.profile.id) {
                this.tempOrders.push(this.orders[this.i]);
            }
        }
        this.product_orders = this.profileService.product_orders;

        if (this.tempOrders.length > 0) {
            this.displayList = true;
        }
    }

    tempOrderId:number;
    productsComplete = 0;
    tempProductOrders: Product_Order[] = [];
    tempProducts = {
        id: 0,
        name: '',
        description: '',
        icon: '',
        price: '',
        categoryId: 0,
        quantity: 1
    };
    tempProductArray: Product[] = [];

    async productsInOrder(order: any) {
        this.tempProductArray.length = 0;
        this.product_orders = this.profileService.product_orders;
        for (this.i = 0; this.i < this.product_orders.length; this.i++) {
            this.tempOrderId=0
            if (order.id == this.product_orders[this.i].orderId) {
                this.productsComplete += this.product_orders[this.i].quantity;
                await this.profileService.getProduct(this.product_orders[this.i].productId)
                this.tempProducts = this.profileService.products;
                this.tempProducts.quantity = this.product_orders[this.i].quantity;
                this.tempProductArray.push(this.tempProducts);
            }
            if (this.productsComplete == order.productCount) {
                break;
            }
        }
    }
}