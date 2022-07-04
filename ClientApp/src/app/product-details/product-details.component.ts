import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from '../model/Product';
import { BaseService } from '../Services/base.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {

  getId: any;

  product: IProduct;

  constructor(private service: BaseService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getId = this.route.snapshot.paramMap.get('id');

    this.getProduct(this.getId);
  }

  getProduct(id: number) {
    return this.service.GetProduct(id).subscribe(response => {
      this.product = response;

    });

  }

}
