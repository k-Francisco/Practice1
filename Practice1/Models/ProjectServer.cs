using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Util;
using Newtonsoft.Json;

namespace Practice1.Models
{

    public class RootObject
    {
        [JsonProperty("feed")]
        public Feed Feed { get; set; }
    }
    public class Feed
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("title")]
        public Title Title { get; set; }
        [JsonProperty("updated")]
        public DateTime Updated { get; set; }
        [JsonProperty("link")]
        public Link Link { get; set; }
        [JsonProperty("entry")]
        public List<Entry> Entry { get; set; }
        [JsonProperty("_xmlns")]
        public string Xmlns { get; set; }
        [JsonProperty("_xmlns:d")]
        public string Xmlnsd { get; set; }
        [JsonProperty("_xmlns:m")]
        public string Xmlnsm { get; set; }
        [JsonProperty("_xml:base")]
        public string Xmlbase { get; set; }
    }
    public class Title
    {
        [JsonProperty("_type")]
        public string Type { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class Link
    {
        [JsonProperty("_rel")]
        public string Rel { get; set; }
        [JsonProperty("_title")]
        public string Title { get; set; }
        [JsonProperty("_href")]
        public string Href { get; set; }
    }
    public class Entry
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("category")]
        public Category Category { get; set; }
        [JsonProperty("link")]
        public List<Link1> Link { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("updated")]
        public DateTime Updated { get; set; }
        [JsonProperty("author")]
        public Author Author { get; set; }
        [JsonProperty("content")]
        public Content Content { get; set; }
    }
    public class Category
    {
        [JsonProperty("_term")]
        public string Term { get; set; }
        [JsonProperty("_scheme")]
        public string Scheme { get; set; }
    }
    public class Link1
    {
        [JsonProperty("_rel")]
        public string Rel { get; set; }
        [JsonProperty("_type")]
        public string Type { get; set; }
        [JsonProperty("_title")]
        public string Title { get; set; }
        [JsonProperty("_href")]
        public string Href { get; set; }
    }
    public class Author
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
    public class Content
    {
        [JsonProperty("properties")]
        public Properties Properties { get; set; }
        [JsonProperty("_type")]
        public string Type { get; set; }
    }
    public class Properties
    {
        [JsonProperty("ProjectId")]
        public ProjectId ProjectId { get; set; }
        [JsonProperty("EnterpriseProjectTypeDescription")]
        public EnterpriseProjectTypeDescription EnterpriseProjectTypeDescription { get; set; }
        [JsonProperty("EnterpriseProjectTypeId")]
        public EnterpriseProjectTypeId EnterpriseProjectTypeId { get; set; }
        [JsonProperty("EnterpriseProjectTypeIsDefault")]
        public EnterpriseProjectTypeIsDefault EnterpriseProjectTypeIsDefault { get; set; }
        [JsonProperty("EnterpriseProjectTypeName")]
        public EnterpriseProjectTypeName EnterpriseProjectTypeName { get; set; }
        [JsonProperty("OptimizerCommitDate")]
        public OptimizerCommitDate OptimizerCommitDate { get; set; }
        [JsonProperty("OptimizerDecisionAliasLookupTableId")]
        public OptimizerDecisionAliasLookupTableId OptimizerDecisionAliasLookupTableId { get; set; }
        [JsonProperty("OptimizerDecisionAliasLookupTableValueId")]
        public OptimizerDecisionAliasLookupTableValueId OptimizerDecisionAliasLookupTableValueId { get; set; }
        [JsonProperty("OptimizerDecisionID")]
        public OptimizerDecisionID OptimizerDecisionID { get; set; }
        [JsonProperty("OptimizerDecisionName")]
        public OptimizerDecisionName OptimizerDecisionName { get; set; }
        [JsonProperty("OptimizerSolutionName")]
        public OptimizerSolutionName OptimizerSolutionName { get; set; }
        [JsonProperty("ParentProjectId")]
        public ParentProjectId ParentProjectId { get; set; }
        [JsonProperty("PlannerCommitDate")]
        public PlannerCommitDate PlannerCommitDate { get; set; }
        [JsonProperty("PlannerDecisionAliasLookupTableId")]
        public PlannerDecisionAliasLookupTableId PlannerDecisionAliasLookupTableId { get; set; }
        [JsonProperty("PlannerDecisionAliasLookupTableValueId")]
        public PlannerDecisionAliasLookupTableValueId PlannerDecisionAliasLookupTableValueId { get; set; }
        [JsonProperty("PlannerDecisionID")]
        public PlannerDecisionID PlannerDecisionID { get; set; }
        [JsonProperty("PlannerDecisionName")]
        public PlannerDecisionName PlannerDecisionName { get; set; }
        [JsonProperty("PlannerEndDate")]
        public PlannerEndDate PlannerEndDate { get; set; }
        [JsonProperty("PlannerSolutionName")]
        public PlannerSolutionName PlannerSolutionName { get; set; }
        [JsonProperty("PlannerStartDate")]
        public PlannerStartDate PlannerStartDate { get; set; }
        [JsonProperty("ProjectActualCost")]
        public ProjectActualCost ProjectActualCost { get; set; }
        [JsonProperty("ProjectActualDuration")]
        public ProjectActualDuration ProjectActualDuration { get; set; }
        [JsonProperty("ProjectActualFinishDate")]
        public ProjectActualFinishDate ProjectActualFinishDate { get; set; }
        [JsonProperty("ProjectActualOvertimeCost")]
        public ProjectActualOvertimeCost ProjectActualOvertimeCost { get; set; }
        [JsonProperty("ProjectActualOvertimeWork")]
        public ProjectActualOvertimeWork ProjectActualOvertimeWork { get; set; }
        [JsonProperty("ProjectActualRegularCost")]
        public ProjectActualRegularCost ProjectActualRegularCost { get; set; }
        [JsonProperty("ProjectActualRegularWork")]
        public ProjectActualRegularWork ProjectActualRegularWork { get; set; }
        [JsonProperty("ProjectActualStartDate")]
        public ProjectActualStartDate ProjectActualStartDate { get; set; }
        [JsonProperty("ProjectActualWork")]
        public ProjectActualWork ProjectActualWork { get; set; }
        [JsonProperty("ProjectACWP")]
        public ProjectACWP ProjectACWP { get; set; }
        [JsonProperty("ProjectAuthorName")]
        public ProjectAuthorName ProjectAuthorName { get; set; }
        [JsonProperty("ProjectBCWP")]
        public ProjectBCWP ProjectBCWP { get; set; }
        [JsonProperty("ProjectBCWS")]
        public ProjectBCWS ProjectBCWS { get; set; }
        [JsonProperty("ProjectBudgetCost")]
        public ProjectBudgetCost ProjectBudgetCost { get; set; }
        [JsonProperty("ProjectBudgetWork")]
        public ProjectBudgetWork ProjectBudgetWork { get; set; }
        [JsonProperty("ProjectCalculationsAreStale")]
        public ProjectCalculationsAreStale ProjectCalculationsAreStale { get; set; }
        [JsonProperty("ProjectCalendarDuration")]
        public ProjectCalendarDuration ProjectCalendarDuration { get; set; }
        [JsonProperty("ProjectCategoryName")]
        public ProjectCategoryName ProjectCategoryName { get; set; }
        [JsonProperty("ProjectCompanyName")]
        public ProjectCompanyName ProjectCompanyName { get; set; }
        [JsonProperty("ProjectCost")]
        public ProjectCost ProjectCost { get; set; }
        [JsonProperty("ProjectCostVariance")]
        public ProjectCostVariance ProjectCostVariance { get; set; }
        [JsonProperty("ProjectCPI")]
        public ProjectCPI ProjectCPI { get; set; }
        [JsonProperty("ProjectCreatedDate")]
        public ProjectCreatedDate ProjectCreatedDate { get; set; }
        [JsonProperty("ProjectCurrency")]
        public ProjectCurrency ProjectCurrency { get; set; }
        [JsonProperty("ProjectCV")]
        public ProjectCV ProjectCV { get; set; }
        [JsonProperty("ProjectCVP")]
        public ProjectCVP ProjectCVP { get; set; }
        [JsonProperty("ProjectDescription")]
        public ProjectDescription ProjectDescription { get; set; }
        [JsonProperty("ProjectDuration")]
        public ProjectDuration ProjectDuration { get; set; }
        [JsonProperty("ProjectDurationVariance")]
        public ProjectDurationVariance ProjectDurationVariance { get; set; }
        [JsonProperty("ProjectEAC")]
        public ProjectEAC ProjectEAC { get; set; }
        [JsonProperty("ProjectEarlyFinish")]
        public ProjectEarlyFinish ProjectEarlyFinish { get; set; }
        [JsonProperty("ProjectEarlyStart")]
        public ProjectEarlyStart ProjectEarlyStart { get; set; }
        [JsonProperty("ProjectEarnedValueIsStale")]
        public ProjectEarnedValueIsStale ProjectEarnedValueIsStale { get; set; }
        [JsonProperty("ProjectEnterpriseFeatures")]
        public ProjectEnterpriseFeatures ProjectEnterpriseFeatures { get; set; }
        [JsonProperty("ProjectFinishDate")]
        public ProjectFinishDate ProjectFinishDate { get; set; }
        [JsonProperty("ProjectFinishVariance")]
        public ProjectFinishVariance ProjectFinishVariance { get; set; }
        [JsonProperty("ProjectFixedCost")]
        public ProjectFixedCost ProjectFixedCost { get; set; }
        [JsonProperty("ProjectIdentifier")]
        public ProjectIdentifier ProjectIdentifier { get; set; }
        [JsonProperty("ProjectKeywords")]
        public ProjectKeywords ProjectKeywords { get; set; }
        [JsonProperty("ProjectLateFinish")]
        public ProjectLateFinish ProjectLateFinish { get; set; }
        [JsonProperty("ProjectLateStart")]
        public ProjectLateStart ProjectLateStart { get; set; }
        [JsonProperty("ProjectLastPublishedDate")]
        public ProjectLastPublishedDate ProjectLastPublishedDate { get; set; }
        [JsonProperty("ProjectManagerName")]
        public ProjectManagerName ProjectManagerName { get; set; }
        [JsonProperty("ProjectModifiedDate")]
        public ProjectModifiedDate ProjectModifiedDate { get; set; }
        [JsonProperty("ProjectName")]
        public ProjectName ProjectName { get; set; }
        [JsonProperty("ProjectOvertimeCost")]
        public ProjectOvertimeCost ProjectOvertimeCost { get; set; }
        [JsonProperty("ProjectOvertimeWork")]
        public ProjectOvertimeWork ProjectOvertimeWork { get; set; }
        [JsonProperty("ProjectOwnerId")]
        public ProjectOwnerId ProjectOwnerId { get; set; }
        [JsonProperty("ProjectOwnerName")]
        public ProjectOwnerName ProjectOwnerName { get; set; }
        [JsonProperty("ProjectPercentCompleted")]
        public ProjectPercentCompleted ProjectPercentCompleted { get; set; }
        [JsonProperty("ProjectPercentWorkCompleted")]
        public ProjectPercentWorkCompleted ProjectPercentWorkCompleted { get; set; }
        [JsonProperty("ProjectRegularCost")]
        public ProjectRegularCost ProjectRegularCost { get; set; }
        [JsonProperty("ProjectRegularWork")]
        public ProjectRegularWork ProjectRegularWork { get; set; }
        [JsonProperty("ProjectRemainingCost")]
        public ProjectRemainingCost ProjectRemainingCost { get; set; }
        [JsonProperty("ProjectRemainingDuration")]
        public ProjectRemainingDuration ProjectRemainingDuration { get; set; }
        [JsonProperty("ProjectRemainingOvertimeCost")]
        public ProjectRemainingOvertimeCost ProjectRemainingOvertimeCost { get; set; }
        [JsonProperty("ProjectRemainingOvertimeWork")]
        public ProjectRemainingOvertimeWork ProjectRemainingOvertimeWork { get; set; }
        [JsonProperty("ProjectRemainingRegularCost")]
        public ProjectRemainingRegularCost ProjectRemainingRegularCost { get; set; }
        [JsonProperty("ProjectRemainingRegularWork")]
        public ProjectRemainingRegularWork ProjectRemainingRegularWork { get; set; }
        [JsonProperty("ProjectRemainingWork")]
        public ProjectRemainingWork ProjectRemainingWork { get; set; }
        [JsonProperty("ProjectResourcePlanWork")]
        public ProjectResourcePlanWork ProjectResourcePlanWork { get; set; }
        [JsonProperty("ProjectSPI")]
        public ProjectSPI ProjectSPI { get; set; }
        [JsonProperty("ProjectStartDate")]
        public ProjectStartDate ProjectStartDate { get; set; }
        [JsonProperty("ProjectStartVariance")]
        public ProjectStartVariance ProjectStartVariance { get; set; }
        [JsonProperty("ProjectStatusDate")]
        public ProjectStatusDate ProjectStatusDate { get; set; }
        [JsonProperty("ProjectSubject")]
        public ProjectSubject ProjectSubject { get; set; }
        [JsonProperty("ProjectSV")]
        public ProjectSV ProjectSV { get; set; }
        [JsonProperty("ProjectSVP")]
        public ProjectSVP ProjectSVP { get; set; }
        [JsonProperty("ProjectTCPI")]
        public ProjectTCPI ProjectTCPI { get; set; }
        [JsonProperty("ProjectTitle")]
        public ProjectTitle ProjectTitle { get; set; }
        [JsonProperty("ProjectType")]
        public ProjectType ProjectType { get; set; }
        [JsonProperty("ProjectVAC")]
        public ProjectVAC ProjectVAC { get; set; }
        [JsonProperty("ProjectWork")]
        public ProjectWork ProjectWork { get; set; }
        [JsonProperty("ProjectWorkspaceInternalUrl")]
        public ProjectWorkspaceInternalUrl ProjectWorkspaceInternalUrl { get; set; }
        [JsonProperty("ProjectWorkVariance")]
        public ProjectWorkVariance ProjectWorkVariance { get; set; }
        [JsonProperty("ResourcePlanUtilizationDate")]
        public ResourcePlanUtilizationDate ResourcePlanUtilizationDate { get; set; }
        [JsonProperty("ResourcePlanUtilizationType")]
        public ResourcePlanUtilizationType ResourcePlanUtilizationType { get; set; }
        [JsonProperty("ProjectDepartments")]
        public ProjectDepartments ProjectDepartments { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
    }
    public class ProjectId
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class EnterpriseProjectTypeDescription
    {
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class EnterpriseProjectTypeId
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class EnterpriseProjectTypeIsDefault
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class EnterpriseProjectTypeName
    {
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class OptimizerCommitDate
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("_m:null")]
        public string Mnull { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
    }
    public class OptimizerDecisionAliasLookupTableId
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("_m:null")]
        public string Mnull { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
    }
    public class OptimizerDecisionAliasLookupTableValueId
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("_m:null")]
        public string Mnull { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
    }
    public class OptimizerDecisionID
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("_m:null")]
        public string Mnull { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
    }
    public class OptimizerDecisionName
    {
        [JsonProperty("_m:null")]
        public string Mnull { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
    }
    public class OptimizerSolutionName
    {
        [JsonProperty("_m:null")]
        public string Mnull { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
    }
    public class ParentProjectId
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("_m:null")]
        public string Mnull { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
    }
    public class PlannerCommitDate
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("_m:null")]
        public string Mnull { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
    }
    public class PlannerDecisionAliasLookupTableId
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("_m:null")]
        public string Mnull { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
    }
    public class PlannerDecisionAliasLookupTableValueId
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("_m:null")]
        public string Mnull { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
    }
    public class PlannerDecisionID
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("_m:null")]
        public string Mnull { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
    }
    public class PlannerDecisionName
    {
        [JsonProperty("_m:null")]
        public string Mnull { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
    }
    public class PlannerEndDate
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("_m:null")]
        public string Mnull { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
    }
    public class PlannerSolutionName
    {
        [JsonProperty("_m:null")]
        public string Mnull { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
    }
    public class PlannerStartDate
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("_m:null")]
        public string Mnull { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
    }
    public class ProjectActualCost
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectActualDuration
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectActualFinishDate
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("_m:null")]
        public string Mnull { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
    }
    public class ProjectActualOvertimeCost
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectActualOvertimeWork
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectActualRegularCost
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectActualRegularWork
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectActualStartDate
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("_m:null")]
        public string Mnull { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
    }
    public class ProjectActualWork
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectACWP
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectAuthorName
    {
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectBCWP
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectBCWS
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectBudgetCost
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectBudgetWork
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectCalculationsAreStale
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectCalendarDuration
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectCategoryName
    {
        [JsonProperty("_m:null")]
        public string Mnull { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
    }
    public class ProjectCompanyName
    {
        [JsonProperty("_m:null")]
        public string Mnull { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
    }
    public class ProjectCost
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectCostVariance
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectCPI
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectCreatedDate
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public DateTime Text { get; set; }
    }
    public class ProjectCurrency
    {
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectCV
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectCVP
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectDescription
    {
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectDuration
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectDurationVariance
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectEAC
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectEarlyFinish
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("_m:null")]
        public string Mnull { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
    }
    public class ProjectEarlyStart
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("_m:null")]
        public string Mnull { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
    }
    public class ProjectEarnedValueIsStale
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectEnterpriseFeatures
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectFinishDate
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public DateTime Text { get; set; }
    }
    public class ProjectFinishVariance
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectFixedCost
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectIdentifier
    {
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectKeywords
    {
        [JsonProperty("_m:null")]
        public string Mnull { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
    }
    public class ProjectLateFinish
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("_m:null")]
        public string Mnull { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
    }
    public class ProjectLateStart
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("_m:null")]
        public string Mnull { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
    }
    public class ProjectLastPublishedDate
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public DateTime Text { get; set; }
    }
    public class ProjectManagerName
    {
        [JsonProperty("_m:null")]
        public string Mnull { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
    }
    public class ProjectModifiedDate
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public DateTime Text { get; set; }
    }
    public class ProjectName
    {
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectOvertimeCost
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectOvertimeWork
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectOwnerId
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectOwnerName
    {
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectPercentCompleted
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectPercentWorkCompleted
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectRegularCost
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectRegularWork
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectRemainingCost
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectRemainingDuration
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectRemainingOvertimeCost
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectRemainingOvertimeWork
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectRemainingRegularCost
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectRemainingRegularWork
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectRemainingWork
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectResourcePlanWork
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectSPI
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectStartDate
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public DateTime Text { get; set; }
    }
    public class ProjectStartVariance
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectStatusDate
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("_m:null")]
        public string Mnull { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
    }
    public class ProjectSubject
    {
        [JsonProperty("_m:null")]
        public string Mnull { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
    }
    public class ProjectSV
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectSVP
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectTCPI
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectTitle
    {
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectType
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectVAC
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectWork
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectWorkspaceInternalUrl
    {
        [JsonProperty("_m:null")]
        public string Mnull { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
    }
    public class ProjectWorkVariance
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ResourcePlanUtilizationDate
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("_m:null")]
        public string Mnull { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
    }
    public class ResourcePlanUtilizationType
    {
        [JsonProperty("_m:type")]
        public string Mtype { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
        [JsonProperty("__text")]
        public string Text { get; set; }
    }
    public class ProjectDepartments
    {
        [JsonProperty("_m:null")]
        public string Mnull { get; set; }
        [JsonProperty("__prefix")]
        public string Prefix { get; set; }
    }


}