import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddStoreFormComponent } from './add-store-form.component';

describe('AddStoreFormComponent', () => {
  let component: AddStoreFormComponent;
  let fixture: ComponentFixture<AddStoreFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddStoreFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddStoreFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
