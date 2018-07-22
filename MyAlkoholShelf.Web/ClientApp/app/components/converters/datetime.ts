import * as moment from "moment";
import 'moment/locale/pl';

export class DatetimeValueConverter {
    toView(value: string) {
        return moment(value).format("LLL");
    }
}
