import { SocietySharedModule } from './society-shared.module';

describe('SocietySharedModule', () => {
  let societySharedModule: SocietySharedModule;

  beforeEach(() => {
    societySharedModule = new SocietySharedModule();
  });

  it('should create an instance', () => {
    expect(societySharedModule).toBeTruthy();
  });
});
