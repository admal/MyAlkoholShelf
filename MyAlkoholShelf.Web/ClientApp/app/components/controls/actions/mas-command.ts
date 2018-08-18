import { bindable, noView } from "aurelia-framework";

@noView
export class MasCommandCustomElement {
    @bindable action() {}

    public execute(): void {
        this.action();
    }
}