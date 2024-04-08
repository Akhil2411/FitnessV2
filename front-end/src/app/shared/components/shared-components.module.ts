import { NgModule } from "@angular/core";
import { FooterComponent } from "./footer/footer.component";
import { HeaderComponent } from "./header/header.component";
import { CommonModule } from "@angular/common";
import { ReactiveFormsModule } from "@angular/forms";
import { DirectivesModule } from "../directives/directives.module";
import { RouterModule } from "@angular/router";



const components=[
    FooterComponent,
    HeaderComponent
];


@NgModule(
    {
        declarations: [
            FooterComponent,
            HeaderComponent
        ],

        imports:[
            CommonModule,
            ReactiveFormsModule,
            DirectivesModule,
            RouterModule
        ],

        exports: [
            FooterComponent,
            HeaderComponent
        ]

    }
)
export class SharedComponentsModule{

}