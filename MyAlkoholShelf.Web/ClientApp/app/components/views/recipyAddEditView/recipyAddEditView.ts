import {ViewBase} from "app/core/viewBase";

export class RecipyAddEditView extends ViewBase
{
    private id: number;

    activate(parameters: any) {
        this.id = parameters.id;
    }
}