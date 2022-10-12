import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { LoginService } from '../authentication/login/service/login.service';
import { Role } from '../models/role';

@Injectable({
    providedIn: 'root'
})
export class RoleAdminGuard implements CanActivate {
    constructor(private loginService: LoginService, private router: Router) { }
    role: Role;
    canActivate() {
        this.role = this.loginService.role;
        if (this.role.id == 1) {
            return true;
        }
       
    }
}
