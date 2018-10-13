import { BackofficeSharedModule } from './backoffice-shared.module';

describe('BackofficeSharedModule', () => {
  let backofficeSharedModule: BackofficeSharedModule;

  beforeEach(() => {
    backofficeSharedModule = new BackofficeSharedModule();
  });

  it('should create an instance', () => {
    expect(backofficeSharedModule).toBeTruthy();
  });
});
