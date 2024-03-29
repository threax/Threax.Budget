import * as client from 'Client/Libs/ServiceClient';
import * as hyperCrud from 'htmlrapier.widgets/src/HypermediaCrudService';
import * as di from 'htmlrapier/src/di';

export class EntryCrudInjector extends hyperCrud.AbstractHypermediaPageInjector {
    public static get InjectorArgs(): di.DiFunction<any>[] {
        return [client.EntryPointInjector];
    }

    constructor(private injector: client.EntryPointInjector) {
        super();
    }

    async list(query: any): Promise<hyperCrud.HypermediaCrudCollection> {
        var entry = await this.injector.load();
        return entry.listEntries(query);
    }

    async canList(): Promise<boolean> {
        var entry = await this.injector.load();
        return entry.canListEntries();
    }

    public getDeletePrompt(item: client.EntryResult): string {
        return "Are you sure you want to delete the entry?";
    }

    public getItemId(item: client.EntryResult): string | null {
        return String(item.data.entryId);
    }

    public createIdQuery(id: string): client.EntryQuery | null {
        return {
            entryId: id
        };
    }
}