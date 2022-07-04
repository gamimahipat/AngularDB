import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from '../home/home.component';
import { CounterComponent } from '../counter/counter.component';
import { LoginComponent } from '../login/login.component';
import { FetchDataComponent } from '../fetch-data/fetch-data.component';
import { ProductDetailsComponent } from '../product-details/product-details.component';
import { ShowProductComponent } from '../show-product/show-product.component';
import { AddToCartComponent } from '../add-to-cart/add-to-cart.component';
import { RegisterComponent } from '../register/register.component';



const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'counter', component: CounterComponent },
  { path: 'fetch-data', component: FetchDataComponent },
  { path: 'login', component: LoginComponent },
  { path: 'show-product', component: ShowProductComponent },
  { path: 'show-product/product-detail/:id', component: ProductDetailsComponent },
  { path: 'addToCart', component: AddToCartComponent },
  { path: 'register', component: RegisterComponent },
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes),
    CommonModule
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
