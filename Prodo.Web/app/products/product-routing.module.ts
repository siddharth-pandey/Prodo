import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ProductListComponent } from './product-list.component';
import { ProductEditorComponent } from './product-editor.component';

const productRoutes: Routes = [
    { path: 'products', component: ProductListComponent },
    { path: 'products/:id', component: ProductEditorComponent }
];

@NgModule({
    imports: [RouterModule.forChild(productRoutes)],
    exports: [RouterModule]
})
export class ProductRoutingModule { }