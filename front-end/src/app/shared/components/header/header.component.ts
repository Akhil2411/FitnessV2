import { Component, ElementRef, Renderer2, ViewChild } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  constructor(private renderer: Renderer2){}

  @ViewChild('headerContainer') headerContainer!:ElementRef;

  openSideBar(){
    let element=this.headerContainer.nativeElement;
    this.renderer.addClass(element, 'open');
  }

  closeSideBar(){
    let element=this.headerContainer.nativeElement;
    this.renderer.removeClass(element, 'open');
  }
}
