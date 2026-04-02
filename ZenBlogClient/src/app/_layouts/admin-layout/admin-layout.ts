import { Component } from '@angular/core';
import { AuthService } from '../../_services/auth-service';

@Component({
  selector: 'app-admin-layout',
  standalone: false,
  templateUrl: './admin-layout.html',
  styleUrl: './admin-layout.css',
})
export class AdminLayout {
  constructor(private authService: AuthService){

  }

  getUserName(){
    let decodedToken = this.authService.decodeToken();
    return decodedToken.name;
  }

  logOut(){
    this.authService.logOut();
  }
}
