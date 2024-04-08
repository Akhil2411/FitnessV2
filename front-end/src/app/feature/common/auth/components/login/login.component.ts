import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{

  isPasswordVisible:boolean=false;
  password:string='';

  loginForm!:FormGroup;

  constructor(private router:Router,private fb:FormBuilder){}

  ngOnInit(): void {
    this.loginForm=this.fb.group({
      email:['',[Validators.required]],
      password:['',[Validators.required]]
    })

  }

  togglePassword(){
    this.isPasswordVisible=!this.isPasswordVisible;
  }

  navigateToHome(){
    this.router.navigate(['/home'])
  }

  onFormSubmit(){
    console.log(this.loginForm)
  }
}
