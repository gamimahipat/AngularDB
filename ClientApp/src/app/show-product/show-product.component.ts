import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { IAddToCart } from '../model/AddToCart';
import { ICategory } from '../model/Category';
import { IProduct } from '../model/Product';
import { BaseService } from '../Services/base.service';


@Component({
  selector: 'app-show-product',
  templateUrl: './show-product.component.html',
  styleUrls: ['./show-product.component.css']
})
export class ShowProductComponent implements OnInit {


  products: IProduct[];
  categories: ICategory[];
 
  selectedCategory = 0;

  addToCartObj: any;




  constructor(private service: BaseService, public toast: ToastrService) { }

  ngOnInit(): void {
    this.getProducts(0);
    this.getCategory();
    
  }

 


  clickMe(id) {
    var userId = localStorage.getItem("userId");
    this.addToCartObj = {
      addToCartID: 0,
      userID: userId,
      user: "string",
      productID: id,
      product: "string",
      quantity: 1
    };
   
    this.postAddToCards();
  }

  postAddToCards() {
    this.service.PostAddToCart(this.addToCartObj).subscribe(response => {
      this.getAddToCards();
      this.toast.success('Add To Cart Success');
    });
  }
  getAddToCards() {
    return this.service.GetAddToCart().subscribe(response => {
      localStorage.setItem('addToCartCount', response.length.toString());
     
    });
  }


  getProducts(categoryId: any) {
    return this.service.GetProducts(categoryId).subscribe(response => {
      this.products = response;

    })

  }

  changeCategory(categoryId: any) {
    this.selectedCategory = categoryId.value;
    this.getProducts(this.selectedCategory);

  }

  getCategory() {
    return this.service.GetCategory().subscribe(response => {
      this.categories = response;
    });
  }



}





