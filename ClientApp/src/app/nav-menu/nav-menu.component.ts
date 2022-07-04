import { AfterViewChecked, AfterViewInit, Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent  {
  
  isExpanded = false;
  constructor( public toast: ToastrService) {

  }

 
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  logout() {
    localStorage.setItem('userName', "null");
    this.toast.error('Logout Success');
  }

  addToCartCount = localStorage.getItem('addToCartCount');
  
  readLocalStorageValue(key) {
    let value = localStorage.getItem(key);
 
    if (value == undefined) {
      value == localStorage.setItem(key,"null");
     
    }
    return value;
  }
}
