import * as standardCrudPage from 'hr.widgets.StandardCrudPage';
import * as startup from 'clientlibs.startup';
import * as deepLink from 'hr.deeplink';
import { EntryCrudInjector } from 'clientlibs.EntryCrudInjector';

import { CrudTableControllerExtensions } from 'hr.widgets.CrudTableController';
import * as client from 'clientlibs.ServiceClient';
import * as controller from 'hr.controller';

class BudgetTableExtensions extends CrudTableControllerExtensions {
    private totalView: controller.IView<client.EntryCollection>;

    public setupBindings(bindings: controller.BindingCollection): void {
        this.totalView = bindings.getView("total");
    }

    public async loadExternalData(pageData: client.EntryCollectionResult): Promise<any> {
        this.totalView.setData(pageData.data);
        return Promise.resolve(null);
    }
}

var injector = EntryCrudInjector;

var builder = startup.createBuilder();
builder.Services.addTransient(CrudTableControllerExtensions, s => new BudgetTableExtensions());
deepLink.addServices(builder.Services);
standardCrudPage.addServices(builder, injector);
standardCrudPage.createControllers(builder, new standardCrudPage.Settings());