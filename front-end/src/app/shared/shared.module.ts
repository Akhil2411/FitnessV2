import { NgModule } from "@angular/core";
import { SharedComponentsModule } from "./components/shared-components.module";
import { DirectivesModule } from "./directives/directives.module";


@NgModule({
    imports:[SharedComponentsModule,DirectivesModule],
    exports:[SharedComponentsModule,DirectivesModule]
})
export class SharedModule{

}