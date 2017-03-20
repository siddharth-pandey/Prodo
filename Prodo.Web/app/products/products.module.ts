import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { ProductListComponent } from './product-list.component';
import { ProductEditorComponent } from './product-editor.component';
import { ProductService } from './product.service';
import { CategoryService } from './category.service';
import { ProductRoutingModule } from './product-routing.module';

@NgModule({
    imports: [CommonModule, FormsModule, ProductRoutingModule],
    declarations: [ProductListComponent, ProductEditorComponent],
    providers: [ProductService, CategoryService]
})
export class ProductsModule { }