import { Directive, ElementRef, HostListener, Input, Renderer2 } from "@angular/core";

@Directive({
    selector:'[appToggleSideBar]'
})
export class ToggleSideBarDirective{


    @Input('appToggleSideBar') isOpen=false;
    constructor(private el:ElementRef,private renderer:Renderer2){}

    @HostListener('click') onClick() {
        let headerContainer = this.findHeaderContainer(this.el.nativeElement);
        if (headerContainer) {
          const currentLeft = parseInt(window.getComputedStyle(headerContainer).left, 10);
          const newLeft = currentLeft === 0 ? -150 : 0;
          this.renderer.setStyle(headerContainer, 'left', newLeft + 'px');
        }

        // const headerContainer = this.el.nativeElement.querySelector('.header-container');
        // if(this.isOpen){
          
        //     this.renderer.setStyle(headerContainer, 'left', 500 + 'px');
        // }
      }

      private findHeaderContainer(element: HTMLElement): HTMLElement|null {
        let parent = element.parentElement;
        while (parent && !parent.classList.contains('header-container')) {
            parent = parent.parentElement;
        }
        return parent;
    }

}