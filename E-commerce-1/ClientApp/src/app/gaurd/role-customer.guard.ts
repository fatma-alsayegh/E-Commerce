import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { LoginService } from '../authentication/login/service/login.service';
import { Role } from '../models/role';

@Injectable({
    providedIn: 'root'
})
export class RoleCustomerGuard implements CanActivate {
    constructor(private loginService: LoginService) { }
    role: Role;
    canActivate() {
        this.role = this.loginService.role;
        if (this.role.id == 2) {
            return true;
        }
    }
}
