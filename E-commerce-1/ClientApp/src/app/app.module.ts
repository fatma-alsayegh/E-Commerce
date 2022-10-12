import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { MatTabsModule } from '@angular/material';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material';
import { MatCardModule } from '@angular/material/card';
import { MatMenuModule } from '@angular/material/menu';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';

//import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './authentication/login/login.component';
import { ProfileComponent } from './authentication/profile/profile.component';
import { AuthGuard } from './gaurd/auth.guard';
import { CategoryComponent } from './Category/category.component';
import { CategoryService } from './Category/service/category.service';
import { ProductComponent } from './Product/product.component';
import { RoleAdminGuard } from './gaurd/role-admin.guard';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { RoleCustomerGuard } from './gaurd/role-customer.guard';
import { AuthenticationService } from './authentication/authentication.service';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        LoginComponent,
        ProfileComponent,
        CategoryComponent,
        ProductComponent,
        ShoppingCartComponent
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        MatIconModule,
        MatDialogModule,
        MatCardModule,
        MatInputModule,
        MatTabsModule, 
        MatMenuModule, MatFormFieldModule, MatButtonModule, MatToolbarModule,
        BrowserAnimationsModule,
        RouterModule.forRoot([
            { path: 'login', component: LoginComponent },
            { path: '', component: HomeComponent},
            { path: 'authentication/profile', component: ProfileComponent ,canActivate: [AuthGuard]},
            { path: 'category', component: CategoryComponent, canActivate: [AuthGuard, RoleAdminGuard] },
            { path: 'product', component: ProductComponent, canActivate: [AuthGuard, RoleAdminGuard] },
            { path: 'shopping-cart', component: ShoppingCartComponent, canActivate: [AuthGuard, RoleCustomerGuard] },

        ]),
    ],
    providers: [ CategoryService, AuthenticationService],
    bootstrap: [AppComponent]
})
export class AppModule { }
