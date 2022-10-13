import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Role } from '../../../models/role';
import { User_Role } from '../../../models/user_role';


@Injectable({
    providedIn: 'root'
})
export class LoginService {
    _baseUrl = '';
    _user_role: User_Role;
    role: Role;
    userId = 0;
    globalAdmin = false;
    globalCustomer = false;
    loggedIn = false;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this._baseUrl = baseUrl;
    }

    async fetchRole(userId) {
        this.role = new Role();
        var response = await this.http.get<User_Role>(this._baseUrl + 'userrole?id=' + userId).toPromise();
        if (response) {
            this._user_role = response[0];
            this.role.id = this._user_role.roleId;
        }
        if (this.role.id == 1) {
            this.globalAdmin = true;
            this.globalCustomer = false;
            this.loggedIn = true;
        }
        if (this.role.id == 2) {
            this.globalAdmin = false;
            this.globalCustomer = true;
            this.loggedIn = true;

        }
    }
}