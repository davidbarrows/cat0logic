export class Human {
    id: number;
    firstName: string;
    lastName: string;
    get fullName(): string {
        debugger;
        let retVal = this.lastName.trim() + ", " + this.firstName.trim(); 
        console.log(retVal);
        return retVal;
    }
}