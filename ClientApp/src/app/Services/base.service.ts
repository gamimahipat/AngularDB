import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from 'oidc-client';
import { IAddToCart } from '../model/AddToCart';
import { ICategory } from '../model/Category';
import { IProduct } from '../model/Product';

@Injectable({
  providedIn: 'root'
})
export class BaseService {

  baseUrl = 'https://localhost:44363/';


  constructor(private http: HttpClient) { }

 // https://localhost:44363/Users

//  AddUser() {
//    return this.http.post<I>(this.baseUrl + 'AddToCarts/' + id);
//}

  DeleteAddToCart(id: any) {
    return this.http.delete<IAddToCart>(this.baseUrl + 'AddToCarts/' + id);
  }

  UpdateAddToCart(addToCart: IAddToCart) {
    return this.http.put<IAddToCart[]>(this.baseUrl + 'AddToCarts/' + addToCart.addToCartID, addToCart);
  }

  GetAddToCart() {
    return this.http.get<IAddToCart[]>(this.baseUrl + 'AddToCarts');
  }

  PostAddToCart(addToCart: IAddToCart[]) {
    return this.http.post(this.baseUrl + 'AddToCarts', addToCart);
  }

  GetProducts(categoryId: any) {
    return this.http.get<IProduct[]>(this.baseUrl + 'Products' + '/?categoryId=' + categoryId);
  }

  GetCategory() {
    return this.http.get<ICategory[]>(this.baseUrl + 'Categories');
  }

  GetProduct(id: any) {
    return this.http.get<IProduct>(this.baseUrl + 'Products/' + id);
  }

}
