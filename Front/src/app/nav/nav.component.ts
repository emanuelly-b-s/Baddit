
import { Component } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import {MatToolbarHarness} from '@angular/material/toolbar/testing';



/**
 * @title Toolbar overview
 */
@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
  standalone: true,
  imports:
    [
      MatToolbarModule,
      MatButtonModule,
      MatIconModule
    ],
})
export class NavComponent {}
