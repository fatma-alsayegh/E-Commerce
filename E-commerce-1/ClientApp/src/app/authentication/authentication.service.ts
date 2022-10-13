import { HttpClient, HttpParams } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Location } from '../models/location';
import { User } from '../models/user';

@Injectable({
    providedIn: 'root'
})
export class AuthenticationService {
    isAuthenticated = false;
    currentUser: User[] = [];
    _baseUrl = '';
    location: Location;
    locationId;

    constructor(private router: Router, @Inject('BASE_URL') baseUrl: string, private http: HttpClient
    ) {
        this._baseUrl = baseUrl;
    }

    authenticate(user: User[]): boolean {
        if (user == null) {
            this.isAuthenticated = false;
            return false;
        }
        else {
            this.currentUser = user;
            this.fetchLocation();
        }
    }

    routeToHome() {
        this.isAuthenticated = true;
        this.router.navigate(['']);
    }

    fetchLocation() {
        this.locationId = this.currentUser[0].locationId;
        const params = new HttpParams()
            .set('id', this.locationId);
        this.http.get<Location>(this._baseUrl + 'location', { params }).subscribe(
            result => {
                this.location = result;
            }, error => {
                console.log(error);
            }
        );
    }

    login() {
        this.router.navigate(['login']);
    }

    logout() {
        this.isAuthenticated = false;
        localStorage.removeItem('email');
        localStorage.removeItem('password');
        localStorage.clear();
        this.router.navigate(['']);
    }
}
