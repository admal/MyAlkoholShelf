import { bindable, bindingMode } from "aurelia-framework";
import { Duration } from "app/models/Duration";

export class MasDurationCustomElement {
    @bindable({ defaultBindingMode: bindingMode.twoWay }) field: Duration;
    @bindable label: string;
}
