import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Response, RequestOptionsArgs, Headers } from "@angular/http";
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

export class Product {
    constructor() {
        this.id = -1;
    }

    id: number;
    categoryId?: number;
    name: string;
    description?: string;
    imageUrl?: string;
    cost?: number;
    outOfStock?: boolean;
}

@Injectable()
export class ProductService {
    baseUrl: string = 'http://localhost:11681/api/products';

    constructor(private http: Http) { }

    isNewProduct(product: Product) {
        return product.id === -1;
    }


    getProductsByCategoryId(categoryId: number): Observable<Product[]> {
        return this.http.get(`http://localhost:11681/api/Categories/${categoryId}/Products`)
            .map((response: Response) => response.json());
    }

    getProducts(): Observable<Product[]> {
        return this.http.get(this.baseUrl)
            .map((response: Response) => response.json());
    }

    getProduct(id: number): Observable<Product> {
        return this.http.get(`${this.baseUrl}/${id}`).map((response: Response) => response.json());
    }

    saveProduct(product: Product): Observable<any> {
        if (this.isNewProduct(product)) {
            return this.http.post(this.baseUrl, product).map((response: Response) => response.json());
        }

        return this.http.put(`${this.baseUrl}/${product.id}`, product).map((response: Response) => response.json());
    }

    deleteProduct(id: number): Observable<any> {
        return this.http.delete(`${this.baseUrl}/${id}`).map((response: Response) => response.json());
    }
}