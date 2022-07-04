import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { BaseService } from '../Services/base.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  title = 'Angular Form Validation Tutorial';
  angForm: FormGroup;
  constructor(private fb: FormBuilder, private service: BaseService) {
    this.createForm();
  }
  createForm() {
    this.angForm = this.fb.group({
      fname: ['', Validators.compose([Validators.pattern('^[a-zA-Z]*$'), Validators.required])],
      lname: ['', Validators.compose([Validators.pattern('^[a-zA-Z]*$'), Validators.required])],
      mnumber: ['', Validators.compose([Validators.pattern('^(91)?[6789]\\d{9}$'), Validators.required])],
      email: ['', Validators.compose([Validators.pattern('^\\w+([\\.-]?\w+)*@\\w+([\\.-]?\w+)*(\\.\\w{2,3})+$'), Validators.required])],
      password: ['', Validators.compose([Validators.pattern('^((?=\\S*[a-z])(?=\\S*[A-Z])(?=\\S*\\d)(?=\\S*[^\\w\\s])\\S{6,20})$'), Validators.required])],
      city: ['', Validators.required],
      hnumber: ['', Validators.required],
      street: ['', Validators.required],
      pin: ['', Validators.compose([Validators.pattern('^[0-9]{6}$'), Validators.required])],
    });
  }

  ngOnInit(): void {
    this.createForm();
  }

  //insertEmployee(myform: NgForm) {
  //  this.service.PostUser()subscribe(d => {
  //    this.resetForm(myform);
  //    this.refereshData();
  //    this.toast.success('Record Saved');
  //  });
  //}

 
}
