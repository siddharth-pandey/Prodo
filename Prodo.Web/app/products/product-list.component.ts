import 'rxjs/add/operator/switchMap';
import { Observable } from 'rxjs/Observable';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';

import { Product, ProductService } from './product.service';
import { Category, CategoryService } from './category.service';

@Component({
    moduleId: module.id,
    selector: 'product-list',
    templateUrl: 'product-list.component.html',
    styleUrls: ['products.css']
})
export class ProductListComponent implements OnInit {
    products: Product[];
    categories: Category[];

    private selectedId: number;

    constructor(private productServiceervice: ProductService, private categoryService: CategoryService,
        private route: ActivatedRoute, private router: Router) { }

    ngOnInit() {
        this.fetchCategories();
        this.fetchProducts();
    }

    fetchProducts() {
        this.productServiceervice.getProducts().subscribe(result => {
            this.products = result;
        },
        error => this.handleError(error));
    }

    fetchCategories() {
        this.categoryService.getCategories().subscribe(result => {
            this.categories = result;
        },
            error => this.handleError(error));
    }

    onProductSelect(product: Product) {
        this.router.navigate(['/products', product.id]);
    }

    onCategorySelect(category: Category) {
        this.productServiceervice.getProductsByCategoryId(category.id).subscribe(result => this.products = result);
    }

    handleError(err: any) {
        console.log('The error is '+ err);
    }
}
