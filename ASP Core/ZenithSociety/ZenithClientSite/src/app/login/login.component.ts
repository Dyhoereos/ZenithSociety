import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormControl, FormGroup } from '@angular/forms';
import { AuthenticationService } from '../authentication.service';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  constructor(private authService: AuthenticationService, private router: Router) {}

  onSubmit(username, password) {
    this.authService.login(username, password).subscribe((result) => {
      if (result) {
        this.router.navigate(['event']);
      }
    });
  }
}
