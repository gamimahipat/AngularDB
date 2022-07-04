import { Component,  OnInit  } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { IAddToCart } from '../model/AddToCart';
import { BaseService } from '../Services/base.service';


@Component({
  selector: 'app-add-to-cart',
  templateUrl: './add-to-cart.component.html',
  styleUrls: ['./add-to-cart.component.css']
})
export class AddToCartComponent implements OnInit {

  addToCards: IAddToCart[];
  updateAddToCartObj: any;

  constructor(private service: BaseService, private router: Router, public toast: ToastrService) {

  }

  ngOnInit() {
    this.getAddToCards();
  }

  userID = localStorage.getItem('userId');

  inc(addToCartId, quantity, productID) {
    if (quantity < 5) {
      quantity++;

      this.updateAddToCartObj = {

        addToCartID: addToCartId,
        userID: this.userID,
        user: "string",
        productID: productID,
        product: "string",
        quantity: quantity,
        image: "string",
        price: 0
      };

      this.updateAddToCart();
  
    }
   
  }

  dec(addToCartID, quantity, productID) {
    if (quantity > 1) {
      quantity--;

      this.updateAddToCartObj = {
        addToCartID: addToCartID,
        userID: this.userID,
        user: "string",
        productID: productID,
        product: "string",
        quantity: quantity
      };

      this.updateAddToCart();
    
    }  
  }
  
  updateAddToCart() {
    this.service.UpdateAddToCart(this.updateAddToCartObj).subscribe((response) => {
      this.getAddToCards();
      
    });
  }

  deleteAddToCart(id: any) {
    

    if (confirm("Are you sure to delete " )) {
      this.service.DeleteAddToCart(id).subscribe((response) => {
        this.getAddToCards();
        this.toast.error('Product Deleted');
      });    
    }
  
  }

  getAddToCards() {
    return this.service.GetAddToCart().subscribe(response => {
      this.addToCards = response;
      localStorage.setItem('addToCartCount', this.addToCards.length.toString());
     
    });
  }

 

}
