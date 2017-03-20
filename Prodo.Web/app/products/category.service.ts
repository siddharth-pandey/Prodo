import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Response, RequestOptionsArgs, Headers } from "@angular/http";
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

export class Category {
    constructor() { }
    id: number;
    name: string;
}

@Injectable()
export class CategoryService {
    baseUrl: string = 'http://localhost:11681/api/categories';
    
    constructor(private http: Http) { }

    getCategories(): Observable<Category[]> {
        return this.http.get(this.baseUrl)
            .map((response: Response) => response.json());
    }

    getCategory(id: number): Observable<Category> {
        return this.http.get(`${this.baseUrl}/${id}`).map((response: Response) => response.json());
    }
}