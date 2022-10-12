import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../authentication/authentication.service';
import { LoginService } from '../authentication/login/service/login.service';
import { Role } from '../models/role';
import { User } from '../models/user';

@Component({
    selector: 'app-nav-menu',
    templateUrl: './nav-menu.component.html',
    styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
    isExpanded = false;
    user: User[] = [];
    _baseUrl = '';
    role: Role;

    constructor(
        private authenticationService: AuthenticationService, private router: Router, private loginService: LoginService,
        @Inject('BASE_URL') baseUrl: string
    ) {
        this._baseUrl = baseUrl;
    }

    ngOnInit(): void {
    }

    collapse() {
        this.isExpanded = false;
    }

    logout() {
        this.authenticationService.logout();
        this.loginService.globalAdmin = false;
        this.loginService.globalCustomer = false;
    }

    async login() {
        await this.authenticationService.login();
        this.role = this.loginService.role;
    }
}
