import { Component, OnInit, NgZone } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { AuthService } from './auth.service';

@Component({
  selector: 'auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss']
})
export class AuthComponent implements OnInit {
  
  constructor(public activeModal: NgbActiveModal, private readonly ngZone: NgZone, private authService: AuthService) { }

  ngOnInit() {
    this.googleSignInButtonHack();
    window['onSignIn'] = (user) => this.ngZone.run(() => {
      this.authService.authenticate(user);
      this.activeModal.close();
    });   
  }

  private googleSignInButtonHack() {
    var script = document.createElement('script');
    script.src = 'https://apis.google.com/js/platform.js';
    document.body.appendChild(script);
  }
}
