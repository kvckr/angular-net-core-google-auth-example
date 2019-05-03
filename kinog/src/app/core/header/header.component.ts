import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AuthComponent } from '../auth/auth.component';
import { AuthService } from '../auth/auth.service';

@Component({
  selector: 'header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  public message: string;

  constructor(private modalService: NgbModal, private authService: AuthService) { }
  
  public openAuthModal() {
    this.modalService.open(AuthComponent, { centered: true });
  }

  public isAuthorized() {
    return this.authService.isAuthorized();
  }

  public testAuth() {
    this.authService.getTestData().subscribe((data) => alert(data));
  }

  ngOnInit() { }
}
