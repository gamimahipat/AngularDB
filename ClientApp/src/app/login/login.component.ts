import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  
  baseUrl = 'https://localhost:44363/Users';
  
  loginForm: FormGroup;

  constructor(private http: HttpClient, private formBuilder: FormBuilder, private router: Router, public toast: ToastrService) {
    
  }

  ngOnInit(): void {

    this.loginForm = this.formBuilder.group({
      email: '',
      customerPassword: ''
    });
    
  }
  
  login() {
    return this.http.get<IUser[]>(this.baseUrl).subscribe(response => {
      const exits = response.find((a: any) => {
        return a.email === this.loginForm.value.email && a.customerPassword === this.loginForm.value.customerPassword
      })
      if (exits) {
        const userName = response[0].firstName + " " + response[0].lastName;
        const userId = response[0].userID;
        localStorage.setItem('userName', userName);
        localStorage.setItem('userId', userId.toString());
        this.toast.success('Login Success');
        this.router.navigate(['/show-product']);

      }
      else {
        alert("Invalid");
      }
    })
    
  }



}

interface IUser {

  userID: number;
  userTypeID: number;
  userType: string;
  firstName: string;
  lastName: string;
  mobileNumber: string;
  email: string;
  customerPassword: string;
  city: string;
  houseNumber: string;
  street: string;
  postalCode: number;
  isActive: boolean;
}


