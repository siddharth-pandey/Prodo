import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { HttpModule } from "@angular/http";
import { ToasterModule } from 'angular2-toaster';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { WelcomeComponent } from './welcome/welcome.component';
import { PageNotFoundComponent } from './page-not-found.component';

import { ProductsModule } from './products/products.module';

@NgModule({
    imports: [HttpModule, BrowserModule, ToasterModule, ProductsModule, AppRoutingModule],
    declarations: [AppComponent, WelcomeComponent, PageNotFoundComponent],
    bootstrap: [AppComponent],
    providers: []
})
export class AppModule { }
