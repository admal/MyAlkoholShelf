import { bindable, bindingMode } from "aurelia-framework";

export class BvfTextareaCustomElement {
    @bindable({ defaultBindingMode: bindingMode.twoWay }) field: string;
    @bindable label: string;
}