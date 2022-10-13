import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { LoginService } from '../authentication/login/service/login.service';
import { Role } from '../models/role';

@Injectable({
    providedIn: 'root'
})
export class RoleAdminGuard implements CanActivate {
    constructor(private loginService: LoginService) { }
    role: Role;
    canActivate() {
        this.role = this.loginService.role;
        if (this.role.id == 1) {
            return true;
        }

    }
}
