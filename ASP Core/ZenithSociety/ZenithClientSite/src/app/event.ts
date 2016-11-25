export class Event {
	eventId: number;
	eventFrom: Date;
	eventTo: Date;
	userId: string;
	applicationUser: string;
	activityId: number;
	activity: string;
	creationDate: Date;
	isActive: boolean

	 constructor(obj?: any ){
	 	this.eventId = obj && obj.eventId || null;
	 	this.eventFrom = obj && obj.eventFrom || null;
	 	this.eventTo = obj && obj.eventTo || null;
	 	this.userId = obj && obj.userId || null;
	 	this.applicationUser = obj && obj.applicationUser || null;
	 	this.activityId = obj && obj.activityId || null;
	 	this.activity = obj && obj.activity || null;
	 	this.creationDate = obj && obj.creationDate || null;
	 	this.isActive = obj && obj.isActive || null;
	 } 
}
