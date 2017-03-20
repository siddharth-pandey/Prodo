import 'rxjs/add/operator/switchMap';
import { Observable } from 'rxjs/Observable';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { ToasterService } from 'angular2-toaster';

import { Product, ProductService } from './product.service';
import { Category, CategoryService } from './category.service';

@Component({
    moduleId: module.id,
    selector: 'product-editor',
    templateUrl: 'product-editor.component.html',
    styleUrls: ['products.css']
})
export class ProductEditorComponent {
    product: Product;
    categories: Category[];
    isEditModeEnabled: boolean = false;

    constructor(private productService: ProductService, private categoryService: CategoryService, private route: ActivatedRoute, private router: Router,
    private toasterService: ToasterService) { }

    ngOnInit() {
        this.setupProduct();
        this.setupCategories();
    }

    setupProduct(): void {
        // (+) converts string 'id' to a number

        this.route.params.subscribe((params: Params) => {
            if (!isNaN(params['id'])) {
                this.productService.getProduct(+params['id']).subscribe((product: Product) => this.product = product);
            } else {
                this.product = new Product();
                this.isEditModeEnabled = true;
            }
        });
    }

    isNewObject(): boolean {
        return this.product.id === undefined;
    }

    saveProduct(product: Product) {
        this.productService.saveProduct(product).subscribe((result) => {
            this.isEditModeEnabled = false;
            this.toasterService.popAsync('success', 'Saved Successfully!');
        });
    }

    setupCategories(): void {
        this.categoryService.getCategories().subscribe((categories: Category[]) => this.categories = categories);
    }
}
