
        
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 
// You can edit this file as your wish.
//------------------------------------------------------------------------------

using System;
using Cooperator.Framework.Data;
using Cooperator.Framework.Core;
using Cooperator.Framework.Core.LazyLoad;
using SISMONRules.Entities;


using SISMONRules.Objects;


using SISMONRules.Gateways;


using SISMONRules.Mappers;


using System.Collections.Generic;

namespace SISMONRules.LazyProviders
{
    /// <summary>
    /// 
    /// </summary>
    public class DefaultLazyProvider: ILazyProvider
    {
        private static Object thisLock = new Object();
        private static Dictionary<string, IGenericGateway> _mappersCache;
        private static Dictionary<string, IGenericGateway> MappersCache
        {
            get
            {
                lock (thisLock)
                {
                    if (DefaultLazyProvider._mappersCache == null)
                    {
                        DefaultLazyProvider._mappersCache = new Dictionary<string, IGenericGateway>();
                        
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Entities.ALERT", SISMONRules.Mappers.ALERTMapper.Instance());
                        
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Objects.ALERTObject", SISMONRules.Gateways.ALERTGateway.Instance());
                    
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Entities.ALERT_TYPE", SISMONRules.Mappers.ALERT_TYPEMapper.Instance());
                        
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Objects.ALERT_TYPEObject", SISMONRules.Gateways.ALERT_TYPEGateway.Instance());
                    
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Entities.COST_REPLACEMENT", SISMONRules.Mappers.COST_REPLACEMENTMapper.Instance());
                        
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Objects.COST_REPLACEMENTObject", SISMONRules.Gateways.COST_REPLACEMENTGateway.Instance());
                    
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Entities.DEPENDENCY", SISMONRules.Mappers.DEPENDENCYMapper.Instance());
                        
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Objects.DEPENDENCYObject", SISMONRules.Gateways.DEPENDENCYGateway.Instance());
                    
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Entities.MODULE", SISMONRules.Mappers.MODULEMapper.Instance());
                        
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Objects.MODULEObject", SISMONRules.Gateways.MODULEGateway.Instance());
                    
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Entities.ORGANIZATION", SISMONRules.Mappers.ORGANIZATIONMapper.Instance());
                        
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Objects.ORGANIZATIONObject", SISMONRules.Gateways.ORGANIZATIONGateway.Instance());
                    
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Entities.ORGANIZATION_LEVELNAME", SISMONRules.Mappers.ORGANIZATION_LEVELNAMEMapper.Instance());
                        
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Objects.ORGANIZATION_LEVELNAMEObject", SISMONRules.Gateways.ORGANIZATION_LEVELNAMEGateway.Instance());
                    
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Entities.PAGE", SISMONRules.Mappers.PAGEMapper.Instance());
                        
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Objects.PAGEObject", SISMONRules.Gateways.PAGEGateway.Instance());
                    
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Entities.PERMISSION", SISMONRules.Mappers.PERMISSIONMapper.Instance());
                        
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Objects.PERMISSIONObject", SISMONRules.Gateways.PERMISSIONGateway.Instance());
                    
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Entities.PROFILE", SISMONRules.Mappers.PROFILEMapper.Instance());
                        
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Objects.PROFILEObject", SISMONRules.Gateways.PROFILEGateway.Instance());
                    
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Entities.PROFILE_PAGE", SISMONRules.Mappers.PROFILE_PAGEMapper.Instance());
                        
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Objects.PROFILE_PAGEObject", SISMONRules.Gateways.PROFILE_PAGEGateway.Instance());
                    
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Entities.PROJECT", SISMONRules.Mappers.PROJECTMapper.Instance());
                        
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Objects.PROJECTObject", SISMONRules.Gateways.PROJECTGateway.Instance());
                    
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Entities.RESOURCE", SISMONRules.Mappers.RESOURCEMapper.Instance());
                        
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Objects.RESOURCEObject", SISMONRules.Gateways.RESOURCEGateway.Instance());
                    
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Entities.STATUS", SISMONRules.Mappers.STATUSMapper.Instance());
                        
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Objects.STATUSObject", SISMONRules.Gateways.STATUSGateway.Instance());
                    
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Entities.TASK", SISMONRules.Mappers.TASKMapper.Instance());
                        
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Objects.TASKObject", SISMONRules.Gateways.TASKGateway.Instance());
                    
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Entities.TASK_ATTACHMENT", SISMONRules.Mappers.TASK_ATTACHMENTMapper.Instance());
                        
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Objects.TASK_ATTACHMENTObject", SISMONRules.Gateways.TASK_ATTACHMENTGateway.Instance());
                    
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Entities.TASK_CONFIGURATION", SISMONRules.Mappers.TASK_CONFIGURATIONMapper.Instance());
                        
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Objects.TASK_CONFIGURATIONObject", SISMONRules.Gateways.TASK_CONFIGURATIONGateway.Instance());
                    
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Entities.TASK_HISTORY", SISMONRules.Mappers.TASK_HISTORYMapper.Instance());
                        
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Objects.TASK_HISTORYObject", SISMONRules.Gateways.TASK_HISTORYGateway.Instance());
                    
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Entities.USER", SISMONRules.Mappers.USERMapper.Instance());
                        
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Objects.USERObject", SISMONRules.Gateways.USERGateway.Instance());
                    
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Entities.USER_PROFILE", SISMONRules.Mappers.USER_PROFILEMapper.Instance());
                        
                        DefaultLazyProvider._mappersCache.Add("SISMONRules.Objects.USER_PROFILEObject", SISMONRules.Gateways.USER_PROFILEGateway.Instance());
                    
                    }
                }
                return DefaultLazyProvider._mappersCache;
            }
        }    


        /// <summary>
        /// Get associated entity for this entity
        /// </summary>
        public IUniqueIdentifiable GetEntity(System.Type child, IUniqueIdentifiable indentifier)
        {
            IGenericGateway genericGateway = DefaultLazyProvider.MappersCache[child.FullName];
            return genericGateway.GetOne(indentifier) as IUniqueIdentifiable;
        }

        /// <summary>
        /// Get collection based in the parent entity
        /// </summary>
        public object GetList(System.Type child, IUniqueIdentifiable parent)
        {
            IGenericGateway genericGateway = DefaultLazyProvider.MappersCache[child.FullName];
            return genericGateway.GetByParent(parent);
        }
    }
}


