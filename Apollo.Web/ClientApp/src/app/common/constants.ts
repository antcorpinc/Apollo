export let CONSTANTS = {

    application: {
        backoffice: 'backoffice',
        society: 'society'
      },
      operation: {
        read: 'read',
        create: 'create',
        edit: 'edit',
        delete: 'delete',
        approve: 'approve',
      },
      feature: {
        backoffice: {
          dashboard: 'BackOfficeDashboard',
          supportuser: 'SupportUser',
          societydashboard: 'BackOfficeSocietyDashboard',
          societyprofile: 'BackOfficeSocietyProfile',
          societyUser: 'SocietyUser',
          backOfficeSupportRoleMgmt: 'BackOfficeSupportRoleMgmt'
        },
        society: {

        }
      },

      create: {
        id: 'A3AFC710-B3E4-40AF-ACA5-20738C86FAA3'
      },

      userTypeId: {
        supportUser: 1,
        societyUser: 2,

      },

      // Info: FeatureTypeId's  are the same Id's as defined in FeatureType enum and Security.Feature table
  featuretypeid: {
    Support: 1041,
    Society: 1042,
    SocietyProfile: 1022,
  },

  snackbar: {
    timeout: 1500
  },

  privilegeType: {
    readOnly: 'VW',
    fullAccess: 'VW|CR|DE|AP'
  },

};
