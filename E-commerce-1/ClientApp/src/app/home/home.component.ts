import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../authentication/authentication.service';
import { LoginService } from '../authentication/login/service/login.service';
import { CategoryService } from '../Category/service/category.service';
import { Product } from '../models/product';
import { ProductService } from '../Product/service/product.service';
import { ShoppingCartService } from '../shopping-cart/service/shopping-cart.service';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']

})
interface Alert {
    type: string;
    message: string;
}
export class HomeComponent implements OnInit {
    products: Product[] = [];
    categoryList: any = [];
    categoryMap: Map<number, string> = new Map();
    filteredCategoryData: any = [];
    tempFilteredData: any = []
    inputnumber = 1;
    dontShowComponent = false;

    constructor(public http: HttpClient,
        public productService: ProductService, public categoryService: CategoryService, public shoopingCartService: ShoppingCartService,
        private loginService: LoginService, private authenticationService: AuthenticationService) {

    }

    ngOnInit() {
        this.fetchAllProducts();
        this.categoryTypesMap();
        if (this.authenticationService.isAuthenticated == false || this.loginService.globalAdmin == true) {
            this.dontShowComponent = true;
        }
    }

    fetchAllProducts() {
        this.productService.getAllProducts().subscribe(
            result => {
                this.products = result;
                this.tempFilteredData = this.products;
                this.products.map(x => {
                    x.quantity = 1;
                })
            }
        )
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
        let value = Number(event.index);
        if (this.tempFilteredData.length < this.products.length) {
            this.tempFilteredData = this.products;
        }
        var list = this.tempFilteredData;
        this.filteredCategoryData.length = 0;
        if (value == 0) {
            return this.fetchAllProducts();
        }
        for (let i = 0; i < list.length; i++) {
            if (value == list[i].categoryId) {
                this.filteredCategoryData.push(this.products[i]);
            }
        }
        this.tempFilteredData = this.filteredCategoryData;
    }

    plus(product: Product) {
        product.quantity += 1;
    }

    minus(product: Product) {
        if (product.quantity < 1) {
            product.quantity = 1;
        }
        if (product.quantity != 1) {
            product.quantity = product.quantity - 1;
        }
    }

    addToCart(product: Product) {
        this.shoopingCartService.addToCart(product);
    }
    alerts: Alert[];

    close(alert: Alert) {
        this.alerts.splice(this.alerts.indexOf(alert), 1);
    }
}