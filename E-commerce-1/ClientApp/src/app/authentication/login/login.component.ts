import { Component, OnInit, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthenticationService } from '../authentication.service';
import { User } from '../../models/user';
import { HttpClient, HttpParams } from '@angular/common/http';
import { LoginService } from './service/login.service';


@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
    user: User[] = [];
    isFormValid = false;
    areCredentialsInvalid = false;
    _baseUrl = '';

    constructor(private authenticationService: AuthenticationService,
        private loginService: LoginService,
        private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this._baseUrl = baseUrl;
    }

    ngOnInit() {
    }

    onSubmit(userForm: NgForm) {
        if (!userForm.valid) {
            this.isFormValid = true;
            this.areCredentialsInvalid = false;
            return;
        }
        const params = new HttpParams()
            .set('email', userForm.value.email)
            .set('password', userForm.value.password);
        this.http.get<User[]>(this._baseUrl + 'users', { params }).subscribe(
            result => {
                this.user = result;
                if (this.user != null) {
                    localStorage.setItem('email', userForm.value.email);
                    localStorage.setItem('password', userForm.value.password);
                    console.log('authenticated');
                    console.log(localStorage);
                    this.authenticationService.authenticate(this.user);
                    this.fetchRole(this.authenticationService.currentUser[0].id);
                }
            }, error => {
                this.isFormValid = false;
                this.areCredentialsInvalid = true;
                console.log(error);
            }
        );
    }

    async fetchRole(userId) {
        await this.loginService.fetchRole(userId);
        this.authenticationService.routeToHome();
    }
}


